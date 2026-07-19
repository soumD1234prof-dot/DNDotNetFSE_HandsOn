using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-consumer-group-2",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("chat-topic");

Console.WriteLine("Consumer 2 listening for chat messages...");

while (true)
{
    var result = consumer.Consume();
    Console.WriteLine($"Received: {result.Message.Value}");
}
