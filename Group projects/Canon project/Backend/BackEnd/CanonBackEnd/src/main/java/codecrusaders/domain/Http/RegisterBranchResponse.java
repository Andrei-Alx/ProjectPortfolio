package codecrusaders.domain.Http;

import codecrusaders.domain.User;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class RegisterBranchResponse {
    private Long id;
    private User user;
}
