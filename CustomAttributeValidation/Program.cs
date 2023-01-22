
using CustomAttributeValidation;
using Newtonsoft.Json;
using System;

var filePath = @"C:\Users\George\source\repos\CustomAttributeValidation\CustomAttributeValidation\request.json";

string json = null;
try
{
    using (StreamReader sr = new StreamReader(filePath))
    {
        json = sr.ReadToEnd();
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine("File not found.");
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}


Customer customer = new Customer();
try
{ 
    JsonConvert.PopulateObject(json, customer);
}
catch (JsonSerializationException ex)
{
    Console.WriteLine("An error occurred while deserializing the JSON: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}

var missingFields = new List<string>();
RequiredAttribute.CheckFields(customer, missingFields);

if (missingFields.Count != 0)
    Console.WriteLine("Missing Fields: " + string.Join(",", missingFields));
else
    Console.WriteLine("There are no missing fields");


