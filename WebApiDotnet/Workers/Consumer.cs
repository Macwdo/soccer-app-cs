// using AutoMapper;
// using ExternalAPI.Workers;
// using Hangfire;
// using MassTransit;
// using ILogger = Serilog.ILogger;
//
//
// public class Consumer : IConsumer<string>
// {
//     private readonly IBus _bus;
//     private readonly ILogger _logger;
//     private readonly IMapper _mapper;
//     private readonly TestWorker _testWorker;
//
//     public Consumer(IBus bus, ILogger logger, TestWorker testWorker)
//     {
//         _bus = bus;
//         _logger = logger;
//         _testWorker = testWorker;
//     }
//
//     public async Task Consume(ConsumeContext<string> context)
//     {
//         var jobId = BackgroundJob.Enqueue(
//             () => _testWorker.run(context.Message)
//         );
//     }
// }