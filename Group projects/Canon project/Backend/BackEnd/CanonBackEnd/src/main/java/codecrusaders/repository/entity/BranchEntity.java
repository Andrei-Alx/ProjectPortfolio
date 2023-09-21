package codecrusaders.repository.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@Table(name = "branches")
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class BranchEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "branchid")
    private Long id;
    @Column(name = "branchname")
    private String branchName;

    @Column(name = "userid")
    private Long userid;

    @Column(name = "ispublic")
    private boolean isPublic;

}

