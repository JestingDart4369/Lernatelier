

var fieldGroups = ["core"];
var timesteps = ["1m", "1h", "1d"];
var location = [47.507885, 8.011956];
var units = ["metric"];
var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://api.tomorrow.io/v4/weather/forecast?location={{location}}&units={{units}}&timesteps={{timesteps}}&apikey=xdM1sxyeGbyfC3XOlTR5ASYplv6TjDVI");
request.Headers.Add("Cookie", "__cf_bm=PP3zBf.zsLa.2lMPEtNu8mORqi3OY0LbKoyIngBpgZM-1761901818-1.0.1.1-x6XALo.0Y2ZVqNFHXWLc074RmW_WwOr13dh2BV.kgxtdJtPlO77DBb8frt6jWAHsAxtytWQDww7bEM7Dehn_t93UzadPa.15rPVuYz94oiA; _cfuvid=7cS7BHlibs18T39DwzEqMPfGF3dkq66UbiDGvXn29p4-1761894604676-0.0.1.1-604800000");
var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());
