//
//  ContentView.swift
//  ReactiveSoundscape
//
//  Created by Andrei Alexandru on 16/10/2023.
//

import SwiftUI

struct ContentView: View {
    var body: some View {
        MusicList()
        LightTaker()
    }
}

#Preview {
    ContentView()
        .environmentObject(ModelData())
}
//look into how many steps the user did that day maybe facial emotion detection instead of an actual mood picker
