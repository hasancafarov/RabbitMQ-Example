using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);


        Console.WriteLine($" Welcome {message}");
    };
    channel.BasicConsume(queue: "NameQueue", //Kuyruk adı
        autoAck: true, //Kuyruk adı doğrulanması
        consumer: consumer);
    Console.ReadLine();
}