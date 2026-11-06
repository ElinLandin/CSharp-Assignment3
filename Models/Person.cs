namespace WestcoastEducationDesktop.Models;

public class Person
{

    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string? PersonalIdNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }


    public override string ToString()
    {
        return $"Förnamn: {FirstName}, Efternamn: {LastName}, " +
                $"Personnummer: {PersonalIdNumber}, Telefonnummer: {PhoneNumber}, " +
                $"Adress: {Address}, Postkod: {PostalCode}, Stad: {City}";
    }

}
