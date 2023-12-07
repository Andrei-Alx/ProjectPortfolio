//
//  RainPredictor.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 07/11/2023.
//

import SwiftUI
import UIKit

struct RainPredictor: View {
    var body: some View {
        VStack {
            Text("The next rainy day is")
                .font(.title)
                .padding()

            HStack {
                Image(systemName: "cloud.heavyrain")
                    .resizable()
                    .foregroundColor(.black)
                    .frame(width: 80, height: 80)
                VStack {
                    Text("9 November 2023")
                        .font(.title2)
                    Text("From 00:00-08:00")
                        .font(.body)
                }
            }
        }
        .padding()
        .background(Color.gray.opacity(0.2))
        .border(Color.white, width: 5)
        .cornerRadius(50)
    }
}

struct RainPredictor_Previews: PreviewProvider {
    static var previews: some View {
        RainPredictor()
    }
}
