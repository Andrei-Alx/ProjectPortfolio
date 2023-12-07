//
//  TempBar.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 01/11/2023.
//

import SwiftUI

struct TempBar: View {
    var sliderValue: Double
    
    var sliderColor: Color {
        switch sliderValue {
        case 0..<33.33:
            return Color.cyan
        case 33.33..<66.67:
            return Color.yellow
        default:
            return Color.red
        }
    }
    
    var body: some View {
        HStack {
            Image(systemName: "thermometer.sun")
                .font(.title2)
            ZStack {
                Text("0")
                    .multilineTextAlignment(.center)
                    .padding(.trailing, 190.0)
                    .padding(.bottom, 45)
                Rectangle()
                    .fill(LinearGradient(gradient: Gradient(colors: [Color.yellow, Color.red]), startPoint: .leading, endPoint: .trailing))
                    .frame(width:200, height: 20)
                Text("60")
                    .multilineTextAlignment(.center)
                    .padding(.leading, 165.0)
                    .padding(.bottom, 40)
                Rectangle()
                    .fill(sliderColor)
                    .frame(width: 15, height: 30)
                    .offset(x: CGFloat((sliderValue / 100 - 0.5) * (200 - 15)), y: 0)
            }
            .padding()
        }
    }
}

struct TempBar_Previews: PreviewProvider {
    static var previews: some View {
        TempBar(sliderValue:60)
    }
}


