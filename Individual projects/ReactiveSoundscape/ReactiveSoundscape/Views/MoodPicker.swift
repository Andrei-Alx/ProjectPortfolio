//
//  MoodPicker.swift
//  ReactiveSoundscape
//
//  Created by Andrei Alexandru on 24/10/2023.
//
import Foundation
import SwiftUI

struct MoodPicker: View {
    @State private var selectedMood: String = ""
    let moods = ["😴", "😭", "😡", "😔", "😃"]

    var body: some View {
        VStack{
            Text("How are you feeling?")
                .font(.system(size: 20))
            HStack {
                        ForEach(moods, id: \.self) { mood in
                            Text(mood)
                                .font(.system(size: 35))
                                .foregroundColor(Color(red: 0.788235294117647, green: 0.3176470588235294, blue: 0.7098039215686275))
                                .padding(.all, 10.0)
                                .background(mood == selectedMood ? Color(red: 0.7987058823529411, green: 0.6745098039215687, blue: 0.907843137254902) : Color.clear)
                                .cornerRadius(10)
                                .onTapGesture {
                                    selectedMood = mood
                                }
                        }
                    }
        }
    }
}

struct MoodPicker_Previews: PreviewProvider {
    static var previews: some View {
        MoodPicker()
    }
}

