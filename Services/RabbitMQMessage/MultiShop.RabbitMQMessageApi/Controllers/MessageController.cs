using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost] 
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);
            var messageContent = "Bugün hava çok soğuk";
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız kuyruğa alınmıştır.");
        }

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var tcs = new TaskCompletionSource<string>();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);


                tcs.SetResult(message);  // Tamamlanma kaynağına alınan mesajı sinyalle
            };

            channel.BasicConsume(queue: "Kuyruk2", autoAck: true, consumer: consumer);

            // Mesaj alınmasını veya zaman aşımını bekle
            var message = await tcs.Task.TimeoutAfter(TimeSpan.FromSeconds(10));

            return Ok(message);
        }
    }

    public static class TaskExtensions
    {
        public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource();
            var delayTask = Task.Delay(timeout, cts.Token);
            var completedTask = await Task.WhenAny(task, delayTask);

            if (completedTask == delayTask)
            {
                throw new TimeoutException("İşlem zaman aşımına uğradı.");
            }

            cts.Cancel();
            return await task;  // Tamamlanan görevin sonucunu döndür
        }
    }
}
