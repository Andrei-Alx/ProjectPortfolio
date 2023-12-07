//
//  Crop.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 31/10/2023.
//

import Foundation
import SwiftUI

struct Crop: Identifiable {
    var id = UUID()
    var name: String
    var temperature: Double
    var humidity: Double
    var imageName: String
    var image: Image {
        Image(imageName)
    }
}
