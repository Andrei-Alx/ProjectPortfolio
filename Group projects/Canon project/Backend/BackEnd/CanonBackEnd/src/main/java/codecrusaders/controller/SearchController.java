package codecrusaders.controller;

import codecrusaders.business.ISearchManager;
import codecrusaders.configuration.security.isauthenticated.IsAuthenticated;
import codecrusaders.domain.SearchResult;
import lombok.AllArgsConstructor;
import lombok.Data;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/search")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH})
public class SearchController {

    @Autowired
    private final ISearchManager manager;

    @GetMapping("/public/error/{errorId}")
    public ResponseEntity<List<SearchResult>> getByErrorIdFromPublic(
            @PathVariable Long errorId,
            @RequestParam(defaultValue = "10") int pageSize,
            @RequestParam(defaultValue = "1") int pageNumber) {
        List<SearchResult> searchResults = manager.getByErrorIdFromPublic(errorId, pageSize, pageNumber);
        return ResponseEntity.ok(searchResults);
    }

    @GetMapping("/public/error/{errorId}/count")
    public ResponseEntity<Integer> countPagesForErrorIdFromPublic(
            @PathVariable Long errorId,
            @RequestParam(defaultValue = "10") int pageSize) {
        int totalPages = manager.countPagesForErrorIdFromPublic(errorId, pageSize);
        return ResponseEntity.ok(totalPages);
    }

    @GetMapping("/public/version/{version}")
    public ResponseEntity<List<SearchResult>> getByVersionFromPublic(
            @PathVariable String version,
            @RequestParam(defaultValue = "10") int pageSize,
            @RequestParam(defaultValue = "1") int pageNumber) {
        List<SearchResult> searchResults = manager.getByVersionFromPublic(version, pageSize, pageNumber);
        return ResponseEntity.ok(searchResults);
    }

    @GetMapping("/public/version/{version}/count")
    public ResponseEntity<Integer> countPagesForVersionFromPublic(
            @PathVariable String version,
            @RequestParam(defaultValue = "10") int pageSize) {
        int totalPages = manager.countPagesForVersionFromPublic(version, pageSize);
        return ResponseEntity.ok(totalPages);
    }
    @GetMapping("/public/commit/{commit}")
    public ResponseEntity<List<SearchResult>> getByCommitFromPublic(
            @PathVariable String commit,
            @RequestParam(defaultValue = "10") int pageSize,
            @RequestParam(defaultValue = "1") int pageNumber) {
        List<SearchResult> searchResults = manager.getByCommitFromPublic(commit, pageSize, pageNumber);
        return ResponseEntity.ok(searchResults);
    }

    @GetMapping("/public/commit/{commit}/count")
    public ResponseEntity<Integer> countPagesForCommitFromPublic(
            @PathVariable String commit,
            @RequestParam(defaultValue = "10") int pageSize) {
        int totalPages = manager.countPagesForCommitFromPublic(commit, pageSize);
        return ResponseEntity.ok(totalPages);
    }

    @IsAuthenticated
    @GetMapping("/private/error/{errorId}")
    public ResponseEntity<List<SearchResult>> getByErrorIdFromPrivate(
            @PathVariable Long errorId,
            @RequestParam Long userId,
            @RequestParam(defaultValue = "10") int pageSize,
            @RequestParam(defaultValue = "1") int pageNumber) {
        List<SearchResult> searchResults = manager.getByErrorIdFromPrivate(errorId, userId, pageSize, pageNumber);
        return ResponseEntity.ok(searchResults);
    }

    @IsAuthenticated
    @GetMapping("/private/error/{errorId}/count")
    public ResponseEntity<Integer> countPagesForErrorIdFromPrivate(
            @PathVariable Long errorId,
            @RequestParam Long userId,
            @RequestParam(defaultValue = "10") int pageSize) {
        int totalPages = manager.countPagesForErrorIdFromPrivate(errorId, userId, pageSize);
        return ResponseEntity.ok(totalPages);
    }

    @IsAuthenticated
    @GetMapping("/private/version/{version}")
    public ResponseEntity<List<SearchResult>> getByVersionFromPrivate(
            @PathVariable String version,
            @RequestParam Long userId,
            @RequestParam(defaultValue = "10") int pageSize,
            @RequestParam(defaultValue = "1") int pageNumber) {
        List<SearchResult> searchResults = manager.getByVersionFromPrivate(version, userId, pageSize, pageNumber);
        return ResponseEntity.ok(searchResults);
    }

    @IsAuthenticated
    @GetMapping("/private/commit/{commit}")
    public ResponseEntity<List<SearchResult>> getByCommitFromPrivate(
            @PathVariable String commit,
            @RequestParam Long userId,
            @RequestParam(defaultValue = "10") int pageSize,
            @RequestParam(defaultValue = "1") int pageNumber) {
        List<SearchResult> searchResults = manager.getByCommitFromPrivate(commit, userId, pageSize, pageNumber);
        return ResponseEntity.ok(searchResults);
    }

    @IsAuthenticated
    @GetMapping("/private/version/{version}/count")
    public ResponseEntity<Integer> countPagesForVersionFromPrivate(
            @PathVariable String version,
            @RequestParam Long userId,
            @RequestParam(defaultValue = "10") int pageSize) {
        int totalPages = manager.countPagesGetByVersionFromPrivate(version, userId, pageSize);
        return ResponseEntity.ok(totalPages);
    }

    @IsAuthenticated
    @GetMapping("/private/commit/{commit}/count")
    public ResponseEntity<Integer> countPagesForCommitFromPrivate(
            @PathVariable String commit,
            @RequestParam Long userId,
            @RequestParam(defaultValue = "10") int pageSize) {
        int totalPages = manager.countPagesGetByCommitFromPrivate(commit, userId, pageSize);
        return ResponseEntity.ok(totalPages);
    }
}
