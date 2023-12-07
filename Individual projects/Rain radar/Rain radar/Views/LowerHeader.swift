//
//  LowerHeader.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 29/10/2023.
//

import SwiftUI

struct LowerHeader: View {
    var body: some View {
        VStack {
            Text("Eindhoven")
                .font(.title)
                .fontWeight(.bold)
                .frame(width: 150, height: 60)
                .background(Color.gray.opacity(0.2))
                .border(Color.white, width: 5)
                .cornerRadius(30)
                .padding(.top, -50)
        }
    }
}
