//
//  LightTaker.swift
//  ReactiveSoundscape
//
//  Created by Andrei Alexandru on 26/10/2023.
//
import SwiftUI
import Combine

struct LightTaker: View {
    @State private var brightness: Double = 0.0
    @EnvironmentObject var modelData: ModelData
    let timer = Timer.publish(every: 20, on: .main, in: .common).autoconnect()

    var body: some View {
        VStack {
            Text("Your screen brightness is: \(String(format: "%.2f", brightness))")
                .padding()
        }
        .onReceive(timer) { _ in
            self.brightness = Double(UIScreen.main.brightness)
            updateTracksBasedOnBrightness()
        }
    }

    func updateTracksBasedOnBrightness() {
        let totalTracks = modelData.allTracks.count
        let intervals = [0.00...0.25, 0.25...0.50, 0.50...0.75, 0.75...1.00]
        let trackCounts = [2, 3, 2, 3]

        for (index, interval) in intervals.enumerated() {
            if interval.contains(brightness) {
                let start = trackCounts.prefix(index).reduce(0, +)
                let end = min(start + trackCounts[index], totalTracks)
                modelData.tracks = Array(modelData.allTracks[start..<end])
                break
            }
        }
    }
}

struct LightTaker_Previews: PreviewProvider {
    static var previews: some View {
        LightTaker()
            .environmentObject(ModelData())
    }
}
