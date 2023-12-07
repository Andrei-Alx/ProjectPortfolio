//
//  HourlyForecast.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 29/10/2023.
//
import SwiftUI

struct HourlyForecast: View {
    let hours = ["13:00", "14:00", "15:00", "16:00", "17:00"]
    let temperatures = ["22°", "23°", "24°", "26°", "25°"]
    let weatherIcons = ["sun.max.fill", "cloud.sun.fill", "cloud.drizzle.fill", "cloud.bolt.rain.fill", "cloud.snow.fill"]
    
    var body: some View {
        HStack {
            ForEach(0..<hours.count) { index in
                VStack {
                    Text(hours[index])
                        .font(.system(size: 15))
                        .foregroundColor(.black)
                    Image(systemName: weatherIcons[index])
                        .resizable()
                        .frame(width: 30, height: 30)
                        .foregroundColor(.black)
                    Text(temperatures[index])
                        .font(.system(size: 15))
                        .foregroundColor(.black)
                }
                .padding()
            }
        }
        .frame(width: 390, height: 120)
        .background(Color.gray.opacity(0.2))
        .border(Color.white, width: 5)
        .cornerRadius(50)
    }
}

//struct HourlyForecast_Previews: PreviewProvider {
//    static var previews: some View {
//        HourlyForecast()
//    }
//}
