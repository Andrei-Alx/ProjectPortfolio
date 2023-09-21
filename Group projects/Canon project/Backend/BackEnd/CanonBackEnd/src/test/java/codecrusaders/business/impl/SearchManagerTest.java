package codecrusaders.business.impl;

import codecrusaders.business.search.SearchManager;
import codecrusaders.repository.*;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.junit.jupiter.MockitoExtension;
import codecrusaders.repository.RegrTestRepository;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;
@ExtendWith(MockitoExtension.class)
public class SearchManagerTest {

    @Mock
    ErrorMessageRepository errorRepository;
    @Mock
    TestStepRepository testStepRepository;
    @Mock
    SubTestRepository subTestRepository;
    @Mock
    RegrTestRepository regressionTestRepository;
    @Mock
    TestSetRepository testSetRepository;
    @Mock
    TestBatchRepository testBatchRepository;
    @Mock
    BranchRepository branchRepository;
    @Mock
    Logger logger = LoggerFactory.getLogger(SearchManager.class);
    @InjectMocks
    SearchManager searchManager;

//    @BeforeEach
//    void setup() {
//        MockitoAnnotations.openMocks(this);
//        BranchEntity branchEntity = new BranchEntity();
//        TestStepEntity testStep = new TestStepEntity();
//        SubTestEntity subTest = new SubTestEntity();
//        RegressionTestEntity regressionTest = new RegressionTestEntity();
//        TestSetEntity testSet = new TestSetEntity();
//        TestBatchEntity testBatch = new TestBatchEntity();
//        when(testStepRepository.findById(anyLong())).thenReturn(Optional.of(testStep));
//        when(subTestRepository.findById(anyLong())).thenReturn(Optional.of(subTest));
//        when(regressionTestRepository.findById(anyLong())).thenReturn(Optional.of(regressionTest));
//        when(testSetRepository.findById(anyLong())).thenReturn(Optional.of(testSet));
//        when(testBatchRepository.findById(anyLong())).thenReturn(Optional.of(testBatch));
//        when(branchRepository.findById(anyLong())).thenReturn(Optional.of(branchEntity));
//    }

//    @Test
//    void getByErrorIdFromPublic_ShouldReturnSearchResults() {
//        // Arrange
//        List<TestStepEntity> testStepEntities = Collections.singletonList(new TestStepEntity(1L,"test", true, 2L,"desc",5L));
//        Pageable pageable = PageRequest.of( 1, 10);
//        Page<TestStepEntity> pageResult = new PageImpl<>(testStepEntities, pageable, testStepEntities.size());
//
//        when(testStepRepository.findByErrorIdFromPublicBranchWithDescOrder(anyLong(), any())).thenReturn(pageResult);
//        when(branchRepository.findById(anyLong())).thenReturn(java.util.Optional.of(new BranchEntity()));
//
//        // Act
//        List<SearchResult> results = searchManager.getByErrorIdFromPublic(123L, 10, 1);
//
//        // Assert
//        PageRequest expectedPageRequest = PageRequest.of(1, 10);
//        verify(testStepRepository).findByErrorIdFromPublicBranchWithDescOrder(eq(123L), eq(expectedPageRequest));
//        verify(branchRepository).findById(anyLong());
//        assertEquals(1, results.size());
//        // Add assertions for the expected values of search results
//    }

    @Test
    void countPagesForErrorIdFromPublic_ShouldReturnTotalPages() {
        // Arrange
        when(testStepRepository.countByErrorIdFromPublicBranch(anyLong())).thenReturn(123);

        // Act
        int totalPages = searchManager.countPagesForErrorIdFromPublic(123L, 10);

        // Assert
        verify(testStepRepository).countByErrorIdFromPublicBranch(eq(123L));
        assertEquals(13, totalPages);
    }

//    @Test
//    void getByVersionFromPublic_ShouldReturnSearchResults() {
//        // Arrange
//        List<TestBatchEntity> testBatchEntities = Collections.singletonList(new TestBatchEntity());
//        Page<TestBatchEntity> pageResult = new PageImpl<>(testBatchEntities);
//        when(testBatchRepository.getTestBatchesByVersionFromPublic(anyString(), any())).thenReturn(pageResult);
//        when(branchRepository.findById(anyLong())).thenReturn(java.util.Optional.of(new BranchEntity()));
//
//        // Act
//        List<SearchResult> results = searchManager.getByVersionFromPublic("1.0", 10, 1);
//
//        // Assert
//        PageRequest expectedPageRequest = PageRequest.of(0, 10);
//        verify(testBatchRepository).getTestBatchesByVersionFromPublic(eq("1.0"), eq(expectedPageRequest));
//        verify(branchRepository).findById(anyLong());
//        assertEquals(1, results.size());
//        // Add assertions for the expected values of search results
//    }

    @Test
    void countPagesForVersionFromPublic_ShouldReturnTotalPages() {
        // Arrange
        when(testBatchRepository.countTestBatchesByVersionFromPublic(anyString())).thenReturn(20);

        // Act
        int totalPages = searchManager.countPagesForVersionFromPublic("1.0", 10);

        // Assert
        verify(testBatchRepository).countTestBatchesByVersionFromPublic(eq("1.0"));
        assertEquals(2, totalPages);
    }

//    @Test
//    void getByCommitFromPublic_ShouldReturnSearchResults() {
//        // Arrange
//        List<TestBatchEntity> testBatchEntities = Collections.singletonList(new TestBatchEntity());
//        Page<TestBatchEntity> pageResult = new PageImpl<>(testBatchEntities);
//        when(testBatchRepository.getTestBatchesByCommitFromPublic(anyString(), any())).thenReturn(pageResult);
//        when(branchRepository.findById(anyLong())).thenReturn(java.util.Optional.of(new BranchEntity()));
//
//        // Act
//        List<SearchResult> results = searchManager.getByCommitFromPublic("12345", 10, 1);
//
//        // Assert
//        PageRequest expectedPageRequest = PageRequest.of(0, 10);
//        verify(testBatchRepository).getTestBatchesByCommitFromPublic(eq("12345"), eq(expectedPageRequest));
//        verify(branchRepository).findById(anyLong());
//        assertEquals(1, results.size());
//        // Add assertions for the expected values of search results
//    }

    @Test
    void countPagesForCommitFromPublic_ShouldReturnTotalPages() {
        // Arrange
        when(testBatchRepository.countTestBatchesByCommitFromPublic(anyString())).thenReturn(20);

        // Act
        int totalPages = searchManager.countPagesForCommitFromPublic("12345", 10);

        // Assert
        verify(testBatchRepository).countTestBatchesByCommitFromPublic(eq("12345"));
        assertEquals(2, totalPages);
    }
}
