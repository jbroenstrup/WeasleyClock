# Weasley Clock

## Backend

## Service

Wir brauchen einen Service, der auf alle Topics unter "owntracks/user" lauscht. Wenn dort ein Topic auftaucht (z. B. owntracks/user/jonas), dann muss die aktuelle Location von Jonas ermittelt werden und wieder an den Broker zurückgeschickt werden unter weasley/jonas. Die Nachrichten auf owntracks/user/# enthalten immer die latitude und longitude des users. Mithilfe des usernames kann die Location im Backend abgefraft werden. Durch einen Http-GET-Request auf __46.38.232.103:3344/api/location?username=jonas&latitude1.23&longitude51.234__ erhält man die Location.

```json
{
  "locationname": "Arbeit",
  "username": "Jonas",
  "latitude": 123,
  "longitude": 4576,
  "maxdistance": 500
}
```
Empfohlene Python Packages: Requests für HTTP, Paho-MQTT für Mqtt, Json für Json-Data
