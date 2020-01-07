namespace BackEnd.Application.ViewModel
{
    using System.Collections.Generic;

    public class ResponseViewModel
    {
        public PageViewModel Page { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ICollection<string> Notifications { get; set; }
    }
}
