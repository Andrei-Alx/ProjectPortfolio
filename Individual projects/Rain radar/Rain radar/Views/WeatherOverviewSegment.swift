//
//  WetherOverviewSegment.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 27/10/2023.
//

import SwiftUI

struct WetherOverviewSegment: View {
    @EnvironmentObject var modelData: ModelData
    
    var body: some View {
        if let weather = modelData.currentWeather { 
            HStack(alignment: .bottom) {
            VStack {
                Image(systemName: "wind")
                    .resizable()
                    .frame(width: 25, height: 25)
                Text("\(String(format: "%.2f", weather.windSpeed)) km/h")
                    .font(.body)
                Text("Wind")
            }
            .padding(.bottom)
            Divider()
            VStack {
                Image(systemName: "drop.fill")
                    .resizable()
                    .frame(width: 20, height: 25)
                Text("\(weather.humidity)%")
                    .font(.body)
                Text("Humidity")
            }
            .padding()
            Divider()
            VStack {
                Image(systemName: "cloud.rain.fill")
                    .resizable()
                    .frame(width: 25, height: 25)
                Text("56%")
                    .font(.body)
                Text("Rain")
            }
            .padding()
        }
        .frame(width: 350, height: 100)
        .background(Color.gray.opacity(0.2))
        .cornerRadius(10)
        }
    }
}

struct WetherOverviewSegment_Previews: PreviewProvider {
    static var previews: some View {
        WetherOverviewSegment()
            .environmentObject(ModelData())
    }
}
