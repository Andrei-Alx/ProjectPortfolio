import SwiftUI

struct MusicList: View {
    @EnvironmentObject var modelData: ModelData

    var body: some View {
        VStack {
            Text("Here are some tracks for you")
                .font(.system(size: 20))
                .padding(.leading, -120.0)
                .bold()
            ScrollView {
                LazyVGrid(columns: Array(repeating: .init(.flexible()), count: 2)) {
                    ForEach(modelData.tracks) {track in
                        MusicCard(music: track)
                            .padding()
                    }
                    .padding(.bottom, -15.0)
                }
            }
        }
    }
}

struct MusicList_Previews: PreviewProvider {
    static var previews: some View {
        MusicList()
            .environmentObject(ModelData())
    }
}
