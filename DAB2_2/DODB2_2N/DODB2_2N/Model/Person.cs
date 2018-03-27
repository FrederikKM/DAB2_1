using Newtonsoft.Json;

namespace DODB2_2N.Model
{

    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "context")]
        public string Context { get; set; }
        [JsonProperty(PropertyName = "name")]
        public Name Name { get; set; }
        [JsonProperty(PropertyName = "telephoneNumbers")]
        public Telephonenumber[] TelephoneNumbers { get; set; }
        [JsonProperty(PropertyName = "primaryAdress")]
        public Primaryadress PrimaryAdress { get; set; }
        [JsonProperty(PropertyName = "secondaryAdress")]
        public Secondaryadress[] SecondaryAdress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Name
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "middleName")]
        public string MiddleName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

    }

    public class Primaryadress
    {
        [JsonProperty(PropertyName = "adressName")]
        public AdressName AdressName { get; set; }
        [JsonProperty(PropertyName = "city")]
        public City City { get; set; }
    }

    public class AdressName
    {
        [JsonProperty(PropertyName = "streetName")]
        public string StreetName { get; set; }
        [JsonProperty(PropertyName = "houseNumber")]
        public string HouseNumber { get; set; }
    }

    public class Telephonenumber
    {
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }
    }

    public class Secondaryadress
    {
        [JsonProperty(PropertyName = "adressName")]
        public AdressName AdressName { get; set; }
        [JsonProperty(PropertyName = "adressType")]
        public string AdressType { get; set; }
        [JsonProperty(PropertyName = "city")]
        public City City { get; set; }
    }

    public class City
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "cityCode")]
        public string CityCode { get; set; }
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }
    }

}