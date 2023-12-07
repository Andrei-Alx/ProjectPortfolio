//
//  PlantAdvice.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 30/10/2023.
//

import Foundation
import SwiftUI

struct PlantAdvice: View {
    @EnvironmentObject var modelData: ModelData
    @State private var advice: String = "Loading advice..."

    var body: some View {
        if let weather = modelData.currentWeather {
            VStack {
                Text("Farming Advice")
                    .font(.largeTitle)
                    .padding()
                Text(advice)
                    .padding()
            }
            .onAppear {
                fetchAdvice(weather: weather)
            }
        }
    }

    func fetchAdvice(weather: Weather) {
//        let humidity = 94
//        let windSpeed = 9.00
//        let temperature = 12
        let humidity = weather.humidity
        let windSpeed = weather.windSpeed
        let temperature = weather.temperature

        if humidity > 90 && temperature < 15 {
            advice = "High humidity and low temperatures can lead to the growth of fungi. Consider using a fungicide since fungi can damage your crops and spread quickly."
        } else if windSpeed > 8 {
            advice = "High wind speeds can cause soil erosion. Consider implementing windbreaks or covering the crops in a greenhouse."
        } else if temperature > 30 {
            advice = "High temperatures can cause heat stress in crops. Ensure adequate crops irrigation."
        } else {
            advice = "Conditions seem normal. Continue regular maintenance and monitoring."
        }
    }
}

struct PlantAdvice_Previews: PreviewProvider {
    static var previews: some View {
        PlantAdvice()
            .environmentObject(ModelData())
    }
}
