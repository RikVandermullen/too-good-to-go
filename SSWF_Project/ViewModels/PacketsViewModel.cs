﻿using Domain;
using DomainServices.Services;

namespace TGTG_Portal.ViewModels
{
    public class PacketsViewModel
    {
        public IEnumerable<Packet> Packets { get; set; } = Enumerable.Empty<Packet>();

        public FormatterService fs = new FormatterService();
    }
}
