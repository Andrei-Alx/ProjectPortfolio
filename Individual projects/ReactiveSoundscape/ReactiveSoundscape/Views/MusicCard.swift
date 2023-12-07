import SwiftUI
import AVKit

struct MusicCard: View {
    @EnvironmentObject var modelData: ModelData
    var music: Music
    @State private var isPlaying = false
    let audioPlayer = AVPlayer()
    
    var audioURL: URL? {
        Bundle.main.url(forResource: music.name, withExtension: "mp3")
    }
    
    var body: some View {
        ZStack {
            LinearGradient(gradient: Gradient(colors: [Color.pink, Color.purple]), startPoint: .top, endPoint: .bottom)
                .cornerRadius(10)
            VStack(alignment: .leading) {
                Text(music.name)
                    .font(.title2)
                    .foregroundColor(.white)
                    .multilineTextAlignment(.leading)
                    .padding(5.0)
                Spacer()
                HStack {
                    Spacer()
                    Button(action: {
                        if self.isPlaying {
                            self.audioPlayer.pause()
                        } else {
                            if let audioURL = self.audioURL,
                               self.audioPlayer.currentItem?.currentTime() == self.audioPlayer.currentItem?.duration {
                                self.audioPlayer.replaceCurrentItem(with: AVPlayerItem(url: audioURL))
                            }
                            self.audioPlayer.play()
                        }
                        self.isPlaying.toggle()
                    }) {
                        HStack {
                            Image(systemName: isPlaying ? "pause.fill" : "play.fill")
                                .resizable()
                                .frame(width: 30, height: 30)
                                .foregroundColor(.white)
                            Text(isPlaying ? "Pause" : "Play")
                                .foregroundColor(.white)
                        }
                        .frame(width: 100, height: 50)
                        .background(Color(red: 0.96, green: 0.441, blue: 0.562))
                        .cornerRadius(10)
                    }
                }
            }
        }
        .frame(width: 170, height: 100)
    }
}

struct MusicCard_Previews: PreviewProvider {
    static var tracks = ModelData().tracks
    
    static var previews: some View {
        MusicCard(music: tracks[0])
            .environmentObject(ModelData())
    }
}
