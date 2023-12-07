//
//  Rain_radarApp.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 27/10/2023.
//

import SwiftUI

@main
struct Rain_radarApp: App {
    @StateObject private var modelData = ModelData()
    
    var body: some Scene {
        WindowGroup {
            ContentView()
                .environmentObject(modelData)
        }
    }
}
