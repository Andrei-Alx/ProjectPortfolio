package codecrusaders.business.impl.converters;

import codecrusaders.domain.Branch;
import codecrusaders.domain.User;
import codecrusaders.repository.entity.BranchEntity;
import codecrusaders.repository.entity.UserEntity;
import lombok.AllArgsConstructor;

import java.util.Optional;

@AllArgsConstructor
public class BranchConverter {
    public static Branch convert(BranchEntity branchEntity){
        return Branch.builder()
                .id(branchEntity.getId())
                .branchName(branchEntity.getBranchName())
                .isPublic(branchEntity.isPublic())
                .userid(branchEntity.getUserid())
                .build();

    }}
