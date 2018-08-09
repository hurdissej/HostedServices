using System;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class QuoteController: Controller 
{
    private readonly QuoteProvider quoteProvider;

    public QuoteController(QuoteProvider QuoteProvider)
    {
        quoteProvider = QuoteProvider;
    }

    [HttpGet]
    public Quote GetQuote()
    {
        return quoteProvider.RandomQuote;
    }
}