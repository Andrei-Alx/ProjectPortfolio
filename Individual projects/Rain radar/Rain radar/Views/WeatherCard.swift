//
//  WetherCard.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 27/10/2023.
//
import SwiftUI

struct WeatherCard: View {
    @EnvironmentObject var modelData: ModelData
    
    var body: some View {
        VStack {
            if let weather = modelData.currentWeather {
                VStack {
                    Text(weather.forecast)
                        .font(.title)
                        .fontWeight(.bold)
                        .padding(.top)
                    HStack {
                        Image(systemName: "cloud.rain")
                            .resizable()
                            .frame(width: 90, height: 90)
                            .padding(.trailing, 60)
                            .foregroundColor(.black)
                        
                        Text("\(weather.temperature)°")
                            .font(.largeTitle)
                        
                    }
                    .padding(.top)
                }
                .frame(width: 330, height: 200)
                .background(Color.gray.opacity(0.2))
                .border(Color.white, width: 5)
                .cornerRadius(50)
            }
        }
    }
}

struct WeatherCard_Previews: PreviewProvider {
    static var previews: some View {
        WeatherCard()
            .environmentObject(ModelData())
    }
}
