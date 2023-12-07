//
//  SearchCrop.swift
//  Rain radar
//
//  Created by Andrei Alexandru on 31/10/2023.
//

import Foundation
import SwiftUI

struct SearchCrop: View {
    @State private var searchText = ""
    @State private var crops = [
        Crop(name: "Red Peppers", temperature: 22, humidity: 60, imageName: "peppers"),
        Crop(name: "Tomatoes", temperature: 24, humidity: 48, imageName: "tomatoes"),
        Crop(name: "Potatoes", temperature: 17, humidity: 56, imageName: "potatoes"),
        Crop(name: "Carrots", temperature: 18, humidity: 41, imageName: "carrots"),
        Crop(name: "Cucumbers", temperature: 21, humidity: 77, imageName: "cucumbers"),
        Crop(name: "Spinach", temperature: 15, humidity: 65, imageName: "spinach"),
        Crop(name: "Lettuce", temperature: 15, humidity: 71, imageName: "salad"),
        Crop(name: "Radishes", temperature: 20, humidity: 62, imageName: "radishes"),
        Crop(name: "Beets", temperature: 20, humidity: 59, imageName: "beetroot"),
        Crop(name: "Onions", temperature: 25, humidity: 38, imageName: "onion"),
        Crop(name: "Sweet Corn", temperature: 18, humidity: 80, imageName: "corn"),
        Crop(name: "Zucchini", temperature: 22, humidity: 82, imageName: "zucchini"),
        Crop(name: "Pumpkins", temperature: 31, humidity: 53, imageName: "pumpkins"),
        Crop(name: "Watermelons", temperature: 27, humidity: 69, imageName:"watermelons"),
        Crop(name:"Eggplants",temperature:17,humidity:80,imageName:"eggplants")
    ]

    var body:some View {
        NavigationView {
            VStack {
                SearchBar(text:$searchText)
                List {
                    ForEach(crops.filter { searchText.isEmpty ? true : $0.name.contains(searchText) }) { crop in
                        VStack(alignment:.leading) {
                            Text(crop.name).font(.headline)
                            TempBar(sliderValue: crop.temperature)
                            HumBar(sliderValue: crop.humidity)
                            Text("Growth rate in The Netherlands:")
                            Image(uiImage:UIImage(named:
                                crop.imageName,in:
                                Bundle.main,compatibleWith:nil) ?? UIImage())
                                .resizable()
                                .scaledToFit()
                        }
                    }
                }
            }.navigationTitle("Crop Search")
        }
    }
}

struct SearchBar:UIViewRepresentable {
    @Binding var text:String

    func makeUIView(context:
        Context) -> UISearchBar {
            let searchBar = UISearchBar(frame:.zero)
            searchBar.delegate = context.coordinator
            return searchBar
    }

    func updateUIView(_ uiView:
        UISearchBar,context:
        Context) {
            uiView.text = text
    }

    func makeCoordinator() -> Coordinator {
        return Coordinator(text:$text)
    }

    class Coordinator:NSObject,UISearchBarDelegate {
        @Binding var text:String

        init(text:
            Binding<String>) {
                _text = text
        }

        func searchBar(_ searchBar:
            UISearchBar,textDidChange searchText:String) {
                text = searchText
            }
        }
}

struct SearchCrop_Previews:
PreviewProvider {
    static var previews:some View {
        SearchCrop()
    }
}
