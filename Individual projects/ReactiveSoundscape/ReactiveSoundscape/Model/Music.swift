import Foundation

struct Music: Hashable, Codable, Identifiable{
    var id: Int
    var name: String
    var duration: TimeInterval?
    
    var category: Category
    enum Category: String, CaseIterable, Codable{
        case relax = "Relax"
        case sleep = "Sleep"
        case sad = "Sad"
        case angry = "Angry"
        case happy = "Happy"
    }
}
