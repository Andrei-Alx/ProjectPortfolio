//
//  HumBar.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 01/11/2023.
//

import SwiftUI

struct HumBar: View {
    var sliderValue: Double
    
    var sliderColor: Color {
        switch sliderValue {
        case 0..<33.33:
            return Color.cyan
        case 33.33..<66.67:
            return Color.blue
        default:
            return Color.purple
        }
    }
    
    var body: some View {
        HStack {
            Image(systemName: "humidity")
                .font(.title2)
            ZStack {
                Text("0")
                    .multilineTextAlignment(.center)
                    .padding(.trailing, 190.0)
                    .padding(.bottom, 45)
                Rectangle()
                    .fill(LinearGradient(gradient: Gradient(colors: [Color.cyan, Color.purple]), startPoint: .leading, endPoint: .trailing))
                    .frame(width:200, height: 20)
                Text("100")
                    .multilineTextAlignment(.center)
                    .padding(.leading, 165.0)
                    .padding(.bottom, 45)
                Rectangle()
                    .fill(sliderColor)
                    .frame(width: 15, height: 30)
                    .offset(x: CGFloat((sliderValue / 100 - 0.5) * (200 - 15)), y: 0)
            }
            .padding()
        }
    }
}

struct HumBar_Previews: PreviewProvider {
    static var previews: some View {
        HumBar(sliderValue:40)
    }
}

