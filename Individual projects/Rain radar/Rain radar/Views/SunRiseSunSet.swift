//
//  SunRiseSunSet.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 29/10/2023.
//

import SwiftUI
import UIKit

struct SunRiseSunSet: View {
    @EnvironmentObject var modelData: ModelData
    
    var body: some View {
        Image(uiImage:UIImage(named:
            "suntimesimple",in:
            Bundle.main,compatibleWith:nil) ?? UIImage())
            .resizable()
            .scaledToFit()
    }
}
