package codecrusaders.business.impl;

import codecrusaders.domain.*;
import codecrusaders.domain.Http.GetAllBranchesResponse;
import codecrusaders.domain.Http.RegisterBranchRequest;
import codecrusaders.domain.Http.RegisterBranchResponse;
import codecrusaders.repository.BranchRepository;
import codecrusaders.repository.TestBatchRepository;
import codecrusaders.repository.entity.BranchEntity;
import codecrusaders.repository.entity.TestBatchEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
public class BranchManagerTest {

    @Mock
    BranchRepository branchRepository;
    @Mock
    TestBatchRepository testBatchRepository;
    @Mock
    AccessToken accessToken;
    @InjectMocks
    BranchManager branchManager;

    //      @Test
//      void shouldSave(){
//            //arrange
//          BranchEntity br = BranchEntity.builder().branchName("name").isPublic(true).build();
//          Branch b = Branch.builder().id(1L).branchName("name").isPublic(true).build();
//          RegisterBranchRequest request = RegisterBranchRequest.builder().branchName("name").isPublic(true).build();
//            when(branchRepository.save(br)).thenReturn(new BranchEntity(1L,"name", true));
//            //act
//            RegisterBranchResponse actualResponse = branchManager.registerBranch(request);
//            //assert
//            assertEquals(actualResponse, b, "Wrong response is returned");
//            verify(branchRepository, description("Save of repo is not called (with correct argument).")).save(br);
//      }
    @Test
    void shouldGetAllPrivateBranches() {
        //arrange
        List<BranchEntity> results = List.of(BranchEntity.builder().id(2L).branchName("name").isPublic(false).build());
        List<Branch> result = List.of(Branch.builder().id(2L).branchName("name").isPublic(false).build());
        when(branchRepository.findAllPrivate(1L)).thenReturn(results);
        when(accessToken.getUserId()).thenReturn(1L);
        //act
        GetAllBranchesResponse actualResponse = branchManager.getAllPrivateBranches();
        //assert
        assertEquals(actualResponse.getBranchList(), result, "Wrong response is returned");
        verify(branchRepository, description("Save of repo is not called (with correct argument).")).findAllPrivate(1L);
    }
    @Test
    void shouldGetAllPublicBranches() {
        //arrange
        List<BranchEntity> results = List.of(BranchEntity.builder().id(2L).branchName("name").isPublic(true).build());
        List<Branch> result = List.of(Branch.builder().id(2L).branchName("name").isPublic(true).build());
        when(branchRepository.findAllPublic()).thenReturn(results);
        //act
        GetAllBranchesResponse actualResponse = branchManager.getAllPublicBranches();
        //assert
        assertEquals(actualResponse.getBranchList(), result, "Wrong response is returned");
        verify(branchRepository, description("Save of repo is not called (with correct argument).")).findAllPublic();
    }
    @Test
    void shouldFindById() {
        //arrange
        BranchEntity br = BranchEntity.builder().id(1L).branchName("name").isPublic(true).build();
        Optional<Branch> b = Optional.of(Branch.builder().id(1L).branchName("name").isPublic(true).build());
        when(branchRepository.findById(1L)).thenReturn(Optional.ofNullable(br));
        //act
        Optional<Branch> actualResponse = branchManager.findById(1L);
        //assert
        assertEquals(actualResponse, b, "Wrong response is returned");
        verify(branchRepository, description("Save of repo is not called (with correct argument).")).findById(1L);
    }
    @Test
    void shouldGetAllTestBatchesFromABranch() {
        //arrange
        LocalDateTime date = null;
        List<TestBatch> tb = List.of(new TestBatch(1L,"test","test2","test3", date, 1L));
        List<TestBatchEntity> tbe = List.of(new TestBatchEntity(1L,"test","test2","test3", date, 1L));
        GetAllTestBatchesFromABranchRequest request = GetAllTestBatchesFromABranchRequest.builder().branchId(1L).build();
        when(testBatchRepository.getAllTestBatchesByBranchEntityId(1L)).thenReturn(tbe);
        //act
        GetAllTestBatchesFromABranchResponse actualResponse = branchManager.getAllTestBatchesFromABranch(request);
        //assert
        assertEquals(actualResponse.getTestBatchList(), tb, "Wrong response is returned");
        verify(testBatchRepository, description("Save of repo is not called (with correct argument).")).getAllTestBatchesByBranchEntityId(1L);
    }
}
