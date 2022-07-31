namespace P01.Stream_Progress
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStremable
    {
        public int Length { get; set; }

        public int BytesSent { get; set; }

    }
}
