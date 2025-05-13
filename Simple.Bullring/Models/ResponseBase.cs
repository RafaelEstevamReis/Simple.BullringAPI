namespace Simple.Bullring.Models;

using System;

public record ResponseBase<T>
{
    public T data { get; set; }
    public Meta meta { get; set; }

    public record Meta
    {
        public int page { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }
}
