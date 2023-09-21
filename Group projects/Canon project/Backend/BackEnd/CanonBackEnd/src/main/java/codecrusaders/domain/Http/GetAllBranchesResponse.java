package codecrusaders.domain.Http;

import codecrusaders.domain.Branch;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class GetAllBranchesResponse {
    private List<Branch> branchList;
}
