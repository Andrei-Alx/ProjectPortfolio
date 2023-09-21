package codecrusaders.domain;

import lombok.Builder;
import lombok.Data;

import java.util.List;

@Data
@Builder
public class GetTestsByTestSetIdResponse {
    private List<RegressionTest> regressionTests;
}
