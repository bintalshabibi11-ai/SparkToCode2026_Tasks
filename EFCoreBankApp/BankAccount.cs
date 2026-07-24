namespace EFCoreBankApp;

public class BankAccount
{
    public int Id { get; set; }

    public string AccountHolderName { get; set; } = string.Empty;

    public decimal Balance { get; set; }
}