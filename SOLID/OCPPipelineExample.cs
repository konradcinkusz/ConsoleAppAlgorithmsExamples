using System.Runtime.CompilerServices;

namespace ConsoleAppAlgorithmsExamples.SOLID;

public enum MeasurementSourceType
{
    Unknown = 0,

    // On-device / wireless
    Ble = 1,             // Bluetooth Low Energy telemetry from hearing aids or wearables
    Wifi = 2,            // Wi-Fi or TCP/IP stream
    FirmwareTelemetry = 3, // On-device diagnostics (CPU, battery, etc.)

    // Laboratory / test benches
    Ultrasonic = 10,     // Acoustic ultrasonic test rigs
    AcousticAnalyzer = 11,
    EnvironmentalSensor = 12, // Temperature, humidity, pressure

    // Manufacturing / quality control
    CalibrationBench = 20, // Calibration & alignment data
    ProductionTester = 21, // Automated tester station

    // Data imports / indirect
    FileImport = 30,     // CSV / JSON file loader
    DatabasePull = 31,   // ETL from legacy DB
    CloudStream = 32     // MQTT / EventHub / Kafka remote stream
}

public interface IMeasurementSource
{
    MeasurementSourceType Kind { get; }                  // e.g., "BLE", "Ultrasonic"
    IAsyncEnumerable<Measurement> ReadAsync(CancellationToken ct);
}

public sealed record Measurement(string DeviceId, DateTimeOffset Ts, string Type, double Value, string Unit);

public interface IMeasurementProcessor
{
    Task ProcessAsync(Measurement m, CancellationToken ct);
}

public sealed class Pipeline
{
    private readonly IEnumerable<IMeasurementSource> _sources;
    private readonly IMeasurementProcessor _processor;

    public Pipeline(IEnumerable<IMeasurementSource> sources, IMeasurementProcessor processor) =>
        (_sources, _processor) = (sources, processor);

    public async Task RunAsync(CancellationToken ct)
    {
        foreach (var src in _sources)    // extension by registration, not modification
            await foreach (var m in src.ReadAsync(ct))
                await _processor.ProcessAsync(m, ct);
    }
}

// New source = new class, no core changes:
public sealed class UltrasonicSource : IMeasurementSource
{
    public MeasurementSourceType Kind => MeasurementSourceType.Ultrasonic;
    public async IAsyncEnumerable<Measurement> ReadAsync([EnumeratorCancellation] CancellationToken ct)
    {
        // read hardware / driver; stubbed:
        yield return new Measurement("dev-42", DateTimeOffset.UtcNow, "Amplitude", 0.89, "Pa");
        await Task.CompletedTask;
    }
}
