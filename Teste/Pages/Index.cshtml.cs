using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Config;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace Teste.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly VaultConfig _vault;

    public IndexModel(ILogger<IndexModel> logger, VaultConfig vault)
    {
        _logger = logger;
        _vault = vault;
    }    

    public void OnGet()
    {
        
    }   
}
