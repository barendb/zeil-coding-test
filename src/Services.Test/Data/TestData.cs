using Newtonsoft.Json;

namespace Services.Test.Data;

public class Card
{
    public string CardType { get; set; }
    public string CardNumber { get; set; }
    public bool Valid { get; set; }
}

public static class TestData
{
    public static TheoryData<Card> Cards
    {
        get
        {
            var json = File.ReadAllText(Path.Combine("Data", "card_data.json"));
            var cards = JsonConvert.DeserializeObject<List<Card>>(json);
            var theoryData = new TheoryData<Card>();
            
            cards?.ForEach(card => theoryData.Add(card));

            return theoryData;
        }
    } 
}