package codecrusaders.business;

import codecrusaders.domain.SearchResult;
import org.springframework.data.domain.Pageable;

import java.util.List;

public interface ISearchManager {

    List<SearchResult> getByErrorIdFromPrivate(Long errorId, Long userId, int pageSize, int pageNumber);
    int countPagesForErrorIdFromPrivate(Long errorId, Long userId, int pageSize);
    List<SearchResult> getByErrorIdFromPublic(Long errorId, int pageSize, int pageNumber);
    int countPagesForErrorIdFromPublic(Long errorId, int pageSize);

    List<SearchResult> getByVersionFromPrivate(String version, Long userId, int pageSize, int pageNumber);
    List<SearchResult> getByVersionFromPublic(String version, int pageSize, int pageNumber);
    int countPagesForVersionFromPublic(String version, int pageSize);

    List<SearchResult> getByCommitFromPrivate(String commit, Long userId, int pageSize, int pageNumber);
    List<SearchResult> getByCommitFromPublic(String commit, int pageSize, int pageNumber);
    int countPagesForCommitFromPublic(String commit, int pageSize);

    int countPagesGetByVersionFromPrivate(String version, Long userId, int pageSize);

    int countPagesGetByCommitFromPrivate(String commit, Long userId, int pageSize);

}
