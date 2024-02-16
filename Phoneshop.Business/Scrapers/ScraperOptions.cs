using System;
using System.Diagnostics.CodeAnalysis;

namespace Phoneshop.Business.Scrapers;

[ExcludeFromCodeCoverage]
public class ScraperOptions
{
    public TimeSpan RequestDelay { get; set; } = TimeSpan.FromSeconds(5);
}