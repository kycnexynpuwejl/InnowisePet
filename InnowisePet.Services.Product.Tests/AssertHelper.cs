using Newtonsoft.Json;

namespace InnowisePet.Services.Product.Tests;

public static class AssertHelper
{
    public static void EqualCollections<T>(IEnumerable<T> expectedList, IEnumerable<T> actualList)
    {
        Assert.Equal(JsonConvert.SerializeObject(expectedList), JsonConvert.SerializeObject(actualList));
    }
    
    public static void NotEqualCollections<T>(IEnumerable<T> expectedList, IEnumerable<T> actualList)
    {
        Assert.NotEqual(JsonConvert.SerializeObject(expectedList), JsonConvert.SerializeObject(actualList));
    }
    
    public static void EqualObjects<T>(T expectedObject, T actualObject)
    {
        Assert.Equal(JsonConvert.SerializeObject(expectedObject), JsonConvert.SerializeObject(actualObject));
    }
    
    public static void NotEqualObjects<T>(T expectedObject, T actualObject)
    {
        Assert.NotEqual(JsonConvert.SerializeObject(expectedObject), JsonConvert.SerializeObject(actualObject));
    }
}