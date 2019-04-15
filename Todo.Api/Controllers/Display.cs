namespace Todo.Api.Controllers
{
    public class Display : IDisplay
    {

        public bool Upper { get; set; }
        private string _signo;
        private ILogger _log;

        public Display(string signo, ILogger log)
        {
            _signo = signo;
            _log = log;
        }

        public string Show(string text)
        {
            var result = $"{text}{_signo}";
            result = Upper ? result.ToUpper() : result.ToLower();
            _log.Log($"{result} Show");
            return result;
        }
    }
}
