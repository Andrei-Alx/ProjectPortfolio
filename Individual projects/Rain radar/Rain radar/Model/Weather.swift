//
//  Weather.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 28/10/2023.
//

import Foundation

struct Weather: Hashable{
    var name: String
    var temperature: Int
    var forecast: String
    var forecastIcon: String
    var windSpeed: Double
    var humidity: Int
    var uvIndex: Int
}
