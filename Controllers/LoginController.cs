using ProjetoBA.Contexts;
using ProjetoBA.Models;
using Microsoft.AspNetCore.Mvc;
 
// 1. Modelo de Dados (representa o que seria enviado do formulário HTML/JS)
public record LoginCredentials(string Email, string Password);
 
// 2. Classe de Serviço (Encapsula a lógica de negócios e validação)
public class TravelBookingAuthService
{
    // O ideal seria usar System.ComponentModel.DataAnnotations para validação,
    // mas aqui recriamos a lógica JavaScript de forma procedural.
 
    // Padrão de Expressão Regular para Email
    private readonly Regex _emailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled);
    private const int MinimumPasswordLength = 6;
 
    /// <summary>
    /// Valida o formato de um endereço de email.
    /// </summary>
    /// <param name="email">O email a ser validado.</param>
    /// <returns>Uma mensagem de erro ou null se válido.</returns>
    public string ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return "Email address is required";
        }
        if (!_emailRegex.IsMatch(email.Trim()))
        {
            return "Please enter a valid email address";
        }
 
        return null; // Válido
    }
 
    /// <summary>
    /// Valida o formato da senha.
    /// </summary>
    /// <param name="password">A senha a ser validada.</param>
    /// <returns>Uma mensagem de erro ou null se válido.</returns>
    public string ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return "Password is required";
        }
 
        if (password.Length < MinimumPasswordLength)
        {
            return $"Password must be at least {MinimumPasswordLength} characters long";
        }
 
        return null; // Válido
    }
 
    /// <summary>
    /// Simula o processo de login assíncrono.
    /// </summary>
    /// <param name="credentials">As credenciais do usuário.</param>
    /// <returns>True se o login for bem-sucedido.</returns>
    /// <exception cref="UnauthorizedAccessException">Lançada em caso de falha de autenticação.</exception>
    public async Task<bool> HandleSubmitAsync(LoginCredentials credentials)
    {
        // 1. Validação completa (simulando a lógica 'isEmailValid' e 'isPasswordValid')
        var emailError = ValidateEmail(credentials.Email);
        if (emailError != null)
        {
            // Em uma API, você retornaria um erro 400 (Bad Request) com esta mensagem.
            Console.WriteLine($"Erro de Validação (Email): {emailError}");
            return false;
        }
 
        var passwordError = ValidatePassword(credentials.Password);
        if (passwordError != null)
        {
            Console.WriteLine($"Erro de Validação (Senha): {passwordError}");
            return false;
        }
 
        // 2. Simulação de autenticação de 2 segundos (simulando a chamada de rede 'await new Promise...')
        Console.WriteLine("Tentando autenticar o usuário...");
        await Task.Delay(2000);
 
        // 3. Simulação de sucesso/falha
        if (credentials.Email.ToLower().Contains("fail"))
        {
            // Lógica de exceção, como no bloco 'catch' do JavaScript
            throw new UnauthorizedAccessException("Sign in failed. Please check your credentials.");
        }
        // Sucesso
        return true;
    }
}
 
// 3. Demonstração da Aplicação (Simulando o uso da classe de serviço)
public class Program
{
    public static async Task Main(string[] args)
    {
        var authService = new TravelBookingAuthService();
        // Caso de Uso 1: Login bem-sucedido
        var successCredentials = new LoginCredentials("teste@exemplo.com", "senha123");
        Console.WriteLine($"--- Tentando Login: {successCredentials.Email} ---");
        await RunLoginSimulation(authService, successCredentials);
 
        Console.WriteLine("\n------------------------------------------------\n");
        // Caso de Uso 2: Login falha na autenticação (simulando o bloco 'catch')
        var failCredentials = new LoginCredentials("user.fail@exemplo.com", "senha123");
        Console.WriteLine($"--- Tentando Login: {failCredentials.Email} ---");
        await RunLoginSimulation(authService, failCredentials);
    }
 
    private static async Task RunLoginSimulation(TravelBookingAuthService authService, LoginCredentials credentials)
    {
        try
        {
            bool success = await authService.HandleSubmitAsync(credentials);
            if (success)
            {
                Console.WriteLine("✅ SUCESSO! Login efetuado. Redirecionando para o dashboard...");
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            // Captura o erro simulado e exibe
            Console.WriteLine($"❌ FALHA: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro Inesperado: {ex.Message}");
        }
    }
}