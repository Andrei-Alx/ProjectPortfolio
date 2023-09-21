package codecrusaders.domain;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class SearchResult {

    Branch branch;
    TestBatch testBatch;
    TestSet testSet;
    RegressionTest regressionTest;
    SubTest subTest;
    TestStep testStep;
    ErrorMessage errorMessage;
}
