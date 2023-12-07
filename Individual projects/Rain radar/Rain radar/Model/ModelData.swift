//
//  ModelData.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 28/10/2023.
//
import Foundation
import Combine

final class ModelData: ObservableObject {
    @Published var currentWeather: Weather?
    @Published var dayInfo: DayInfo = DayInfo(sunrise: "00:00 AM", sunset: "00:00 PM")
    
    init() {
        getCurrentWeather()
        getSunriseSunset()
    }
    
    func getCurrentWeather() {
        let headers = [
            "X-RapidAPI-Key": "185fae5b88msh87a95976a82b760p1f1ee8jsnf8521630cea5",
            "X-RapidAPI-Host": "weatherapi-com.p.rapidapi.com"
        ]

        let request = NSMutableURLRequest(url: NSURL(string: "https://weatherapi-com.p.rapidapi.com/current.json?q=Eindhoven")! as URL,
                                            cachePolicy: .useProtocolCachePolicy,
                                            timeoutInterval: 10.0)
        request.httpMethod = "GET"
        request.allHTTPHeaderFields = headers

        let session = URLSession.shared
        var weatherResult : Weather? = nil

        let semaphore = DispatchSemaphore(value: 0)

        let dataTask = session.dataTask(with: request as URLRequest) { (data, response, error) in
            if let error = error {
                print(error)
                semaphore.signal()
                return
            } else if let data = data {
                do {
                    if let jsonResult = try JSONSerialization.jsonObject(with: data, options: .mutableLeaves) as? [String:Any] {
                        if let location = jsonResult["location"] as? [String:Any],
                           let current = jsonResult["current"] as? [String:Any],
                           let condition = current["condition"] as? [String:Any] {
                            weatherResult = Weather(
                                name: location["name"] as? String ?? "",
                                temperature: current["temp_c"] as? Int ?? 0,
                                forecast: condition["text"] as? String ?? "",
                                forecastIcon: condition["icon"] as? String ?? "",
                                windSpeed: current["wind_kph"] as? Double ?? 0.0,
                                humidity: current["humidity"] as? Int ?? 0,
                                uvIndex: current["uv"] as? Int ?? 0
                            )
                        }
                    }
                } catch {
                    print("Error decoding JSON: \(error)")
                }
            }
            semaphore.signal()
        }
        dataTask.resume()
        _ = semaphore.wait(timeout: DispatchTime.distantFuture)
        DispatchQueue.main.async {
            self.currentWeather = weatherResult
        }
    }
    
    func getSunriseSunset() {
        let headers = [
            "X-RapidAPI-Key": "185fae5b88msh87a95976a82b760p1f1ee8jsnf8521630cea5",
            "X-RapidAPI-Host": "weatherapi-com.p.rapidapi.com"
        ]

        let request = NSMutableURLRequest(url: NSURL(string: "https://weatherapi-com.p.rapidapi.com/astronomy.json?q=Eindhoven")! as URL,
                                            cachePolicy: .useProtocolCachePolicy,
                                            timeoutInterval: 10.0)
        request.httpMethod = "GET"
        request.allHTTPHeaderFields = headers

        let session = URLSession.shared
        let dataTask = session.dataTask(with: request as URLRequest, completionHandler: { (data, response, error) -> Void in
            if let error = error {
                print(error)
            } else if let data = data {
                do {
                    if let jsonResult = try JSONSerialization.jsonObject(with: data, options: .mutableLeaves) as? [String: Any],
                       let astronomy = jsonResult["astronomy"] as? [String: Any],
                       let astro = astronomy["astro"] as? [String: Any],
                       let sunrise = astro["sunrise"] as? String,
                       let sunset = astro["sunset"] as? String {
                        DispatchQueue.main.async {
                            self.dayInfo = DayInfo(sunrise: sunrise, sunset: sunset)
                        }
                        print("Sunrise: \(self.dayInfo.sunrise), Sunset: \(self.dayInfo.sunset)")
                    }
                } catch {
                    print("Error decoding JSON: \(error)")
                }
            }
        })
        dataTask.resume()
    }
}
