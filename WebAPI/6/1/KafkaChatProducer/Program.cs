using Confluent.Kafka;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Kafka Chat Producer - type a message and press Enter (type 'exit' to quit)");

while (true)
{
    string? message = Console.ReadLine();
    if (message == "exit") break;

    var result = await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
    Console.WriteLine($"Delivered to: {result.TopicPartitionOffset}");
}
