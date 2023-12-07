//
//  ContentView.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 27/10/2023.
//

import SwiftUI

struct ContentView: View {
    @EnvironmentObject var modelData: ModelData
    @State private var selection: Tab = .forecast
    
    enum Tab {
        case home
        case crops
        case forecast
    }
    
    var body: some View {
        TabView(selection: $selection){
            VStack(alignment: .center) {
                Header()
                if modelData.currentWeather != nil {
                    WeatherCard()
                }
                Spacer()
                    .frame(width: 0.0, height: 50.0)
                WetherOverviewSegment()
                Spacer()
                    .frame(width: 0.0, height: 50.0)
                RainPredictor()
            }
            .tabItem { Label("Home", systemImage: "house") }
            .padding(.bottom, 70.0)
            
            VStack(alignment: .center) {
                VStack(spacing: 25) {
                            SunRiseSunSet()
                            HourlyForecast()
                            PlantAdvice()
                        }
                        .padding(.bottom, 100)
            }
            .tabItem { Label("Forecast", systemImage: "calendar") }
            
            VStack(alignment: .center) {
                SearchCrop()
            }
            .tabItem { Label("Crops", systemImage: "carrot") }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
            .environmentObject(ModelData())
    }
}
