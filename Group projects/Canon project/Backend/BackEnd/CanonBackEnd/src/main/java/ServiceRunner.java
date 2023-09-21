import codecrusaders.Main;
import codecrusaders.business.AccessTokenDecoder;
import codecrusaders.business.IBranchManager;
import codecrusaders.business.ISearchManager;
import codecrusaders.business.ITestStepManager;
import codecrusaders.business.impl.BranchManager;
import codecrusaders.business.impl.UserManager;
import codecrusaders.business.search.SearchManager;
import codecrusaders.business.impl.TestStepManager;
import codecrusaders.domain.AccessToken;
import codecrusaders.domain.Http.RegisterUserRequest;
import codecrusaders.domain.Http.RegisterUserResponse;
import codecrusaders.domain.SearchResult;
import codecrusaders.domain.TestStep;
import codecrusaders.domain.User;
import codecrusaders.repository.*;
import codecrusaders.repository.entity.*;
import org.springframework.boot.SpringApplication;
import org.springframework.context.ConfigurableApplicationContext;

import java.sql.Timestamp;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.*;
//QUERY TO DELETE ALL
//delete FROM dbcanon.teststeps;
//        delete FROM dbcanon.subtests;
//        delete FROM dbcanon.tests;
//        delete FROM dbcanon.testsets;
//        delete FROM dbcanon.testbatches;
//        delete FROM dbcanon.branches;
//        delete FROM dbcanon.users;

public class ServiceRunner {
    public static void main(String[] args){
        try{
            ConfigurableApplicationContext context = SpringApplication.run(Main.class, args);
            BranchRepository branchRepository = context.getBean(BranchRepository.class);
            TestBatchRepository testBatchRepository = context.getBean(TestBatchRepository.class);
            TestSetRepository testSetRepository = context.getBean(TestSetRepository.class);
            RegrTestRepository regressionTesRepository = context.getBean(RegrTestRepository.class);
            SubTestRepository subTestRepository = context.getBean(SubTestRepository.class);
            TestStepRepository testStepRepository = context.getBean(TestStepRepository.class);
            ErrorMessageRepository errorMessageRepository = context.getBean(ErrorMessageRepository.class);
            AccessTokenDecoder decoder = context.getBean(AccessTokenDecoder.class);
            UserManager userManager = context.getBean(UserManager.class);

//            String accessTokenEncoded = "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJEZW1vIiwiaWF0IjoxNjg3MzM3MzEwLCJleHAiOjE2ODczMzkxMTAsInVzZXJJZCI6NX0.TXjwn3ETCnZ1fUEhNuUwHbGOybM4VB7DzyhMajRkvEQ";
//            AccessToken token = decoder.decode(accessTokenEncoded);
//            System.out.println(token.getUserId());

//            //Create errors:
//            List<ErrorEntity> errorEntities = generateMockErrors().stream().toList();
//            for(int i = 0; i < errorEntities.size(); i++){
//                errorMessageRepository.save(errorEntities.get(i));
//            }
//            System.out.println("Finished creating errors");

            if(1 == 1){
                throw new RuntimeException("Mock data is already saved");
            }

            //Create Users:
            RegisterUserRequest request = RegisterUserRequest.builder().username("Demo").password("Password123").build();
            RegisterUserResponse response = userManager.registerUser(request);
            Long userId = response.getId();
            System.out.println("Created User ID: " + userId.toString());

            RegisterUserRequest request1 = RegisterUserRequest.builder().username("AnotherDemo").password("Password123").build();
            RegisterUserResponse response1 = userManager.registerUser(request1);
            Long userId1 = response1.getId();
            System.out.println("Created User ID: " + userId.toString());
            //Create mock branch data:

            BranchEntity branchData = BranchEntity.builder()
                    .branchName("DEMO-DEVELOPMENT-BRANCH")
                    .isPublic(false)
                    .userid(userId)
                    .build();
            BranchEntity branch = branchRepository.save(branchData);
            System.out.println("Created Branch: " + branch.toString());

            BranchEntity branchData2 = BranchEntity.builder()
                    .branchName("ANOTHERDEMO-DEVELOPMENT-BRANCH")
                    .isPublic(false)
                    .userid(userId1)
                    .build();
            BranchEntity branch2 = branchRepository.save(branchData2);
            System.out.println("Created Branch: " + branch2.toString());

            BranchEntity branchData1 = BranchEntity.builder()
                    .branchName("Main")
                    .isPublic(true)
                    .build();
            BranchEntity branch1 = branchRepository.save(branchData1);
            System.out.println("Created Branch: " + branch1.toString());

            //Create mock test batch data:
            List<BranchEntity> branchEntityList = branchRepository.findAll().stream().toList();
            for(int i = 0; i < branchEntityList.size(); i++){

                for (int j = 0; j < 20; j++) {
                    TestBatchEntity testBatchEntity = TestBatchEntity.builder()
                            .buildTime("Build Time - " + (j + 1))
                            .version("1." + (j + 1))
                            .commitShal(UUID.randomUUID().toString())
                            .dateTime(LocalDateTime.now())
                            .branchId(branchEntityList.get(i).getId())
                            .build();
                    testBatchRepository.save(testBatchEntity);
                }
            }
            System.out.println("Finished creating branches");

            //Create mock test set data:
            List<TestBatchEntity> testBatchEntityList = testBatchRepository.findAll().stream().toList();
            for(int i = 0; i < testBatchEntityList.size(); i++){

                for (int j = 0; j < 3; j++) {
                    TestSetEntity testSetEntity = TestSetEntity.builder()
                            .testSetName("TestSetName - " + (j+1))
                            .testSetTime(generateRandomDate())
                            .testBatchId(testBatchEntityList.get(i).getId())
                            .build();
                    testSetRepository.save(testSetEntity);
                }
            }
            System.out.println("Finished creating testbatches");

            //Create mock regression test data:
            List<TestSetEntity> testSetEntities = testSetRepository.findAll().stream().toList();
            for(int i = 0; i < testSetEntities.size(); i++){
                for(int j = 0; j < 5; j++){
                    RegressionTestEntity regressionTestEntity = RegressionTestEntity.builder()
                            .testDate(LocalDateTime.now())
                            .testName("Test name - " + (j+1))
                            .testSetId(testSetEntities.get(i).getId())
                            .build();
                    regressionTesRepository.save(regressionTestEntity);
                }
            }
            System.out.println("Finished creating test sets");

            //Create mock subtest data:
            List<RegressionTestEntity> regressionTestEntities = regressionTesRepository.findAll().stream().toList();
            for(int i = 0; i < regressionTestEntities.size(); i++){
                for(int j = 0; j < 10; j++){
                    SubTestEntity subTestEntity = SubTestEntity.builder()
                            .subTestName("Sub Test Name - " + (j+1))
                            .testID(regressionTestEntities.get(i).getId())
                            .build();
                    subTestRepository.save(subTestEntity);
                }
            }
            System.out.println("Finished creating subtests");

            //Create mock test step data:
            List<SubTestEntity> subTestEntities = subTestRepository.findAll().stream().toList();
            for(int i = 0; i < subTestEntities.size(); i++){
                for(int j = 0; j < 10; j++){
                    TestStepEntity testStepEntity = TestStepEntity.builder()
                            .testStepName("Test Step Name - " + (j+1))
                            .description("<< Here comes the description >>")
                            .testResult(true)
                            .subTestID(subTestEntities.get(i).getId())
                            .build();

                    if(!generateMostlyTrueBoolean(98)){
                        testStepEntity.setErrorID(generateRandomLongForErrorId(1L, 10L));
                        testStepEntity.setTestResult(false);
                    }
                    testStepRepository.save(testStepEntity);
                }
            }
            System.out.println("Finished creating test steps");
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }
    }


    private static Date generateRandomDate() {
        long offset = Timestamp.valueOf("2021-01-01 00:00:00").getTime();
        long end = Timestamp.valueOf("2023-05-31 23:59:59").getTime();
        long diff = end - offset + 1;
        long randomTimestamp = offset + (long) (Math.random() * diff);

        return new Date(randomTimestamp);
    }

    private static boolean generateMostlyTrueBoolean(int probability) {
        //probability from 0 to 100;
        Random random = new Random();
        return random.nextInt(100) < probability;
    }
    private static long generateRandomLongForErrorId(long minValue, long maxValue) {
        Random random = new Random();
        long range = maxValue - minValue + 1;
        long randomNumber = Math.abs(random.nextLong() % range);
        return minValue + randomNumber;
    }


    private static List<ErrorEntity> generateMockErrors(){

        List<ErrorEntity> errorEntities = new ArrayList<>();

        String[] errorMessages = {
                "Null Pointer Exception",
                "Invalid Argument",
                "File Not Found",
                "Database Connection Error",
                "Access Denied",
                "Invalid Format",
                "Timeout Exception",
                "Authentication Failed",
                "Network Unreachable",
                "Invalid Request"
        };

        for(int i = 0; i < errorMessages.length; i++){
            ErrorEntity errorEntity = ErrorEntity.builder()
                    .errorMessage(errorMessages[i])
                    .errorid((long) (i+1)).build();
            errorEntities.add(errorEntity);
        }
        return errorEntities;
    }
}
