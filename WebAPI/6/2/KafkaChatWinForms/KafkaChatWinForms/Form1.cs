using Confluent.Kafka;

namespace KafkaChatWinForms
{
    public partial class Form1 : Form
    {
        private readonly IProducer<Null, string> _producer;

        public Form1()
        {
            InitializeComponent();
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            if (string.IsNullOrWhiteSpace(message)) return;

            await _producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
            lstSentMessages.Items.Add($"Sent: {message}");
            txtMessage.Clear();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _producer.Dispose();
            base.OnFormClosed(e);
        }
    }
}